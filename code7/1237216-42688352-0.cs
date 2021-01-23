        protected void ReaderFPMachine()
        {
            _readerCollection = ReaderCollection.GetReaders();
            foreach (Reader Reader in _readerCollection)
            {
                _fPMachineID = Reader.Description.SerialNumber;
                break;
            }
            this.CheckFingerPrint();
        }
        protected void CheckFingerPrint()
        {
            try
            {
                _finger = null;
                _reader = _readerCollection[0];
                if (!OpenReader())
                {
                    //this.Close();
                }
                if (!StartCaptureAsync(this.OnCaptured))
                {
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                _finger = null;
                // Check capture quality and throw an error if bad.
                if (!CheckCaptureResult(captureResult)) return;
                //SendMessage(Action.SendMessage, "A finger was captured.");
                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _reset = true;
                    throw new Exception(resultConversion.ResultCode.ToString());
                }
                _finger = resultConversion.Data;
                _fingerPrintID = Fmd.SerializeXml(_finger);
                //MsVisitorHd _msVisitorHd = this._vMSBL.GetSingleMsVisitorHdByFingerPrintID(_fingerXML);
                //List<MsVisitorHd> _listMsVisitorHd = this._vMSBL.GetListMsVisitorHd();
                bool _exist = false;
                //foreach (var _item in _listMsVisitorHd)
                //{
                //    Fmd _fmd = Fmd.DeserializeXml(_fingerPrintID);
                //    Fmd _fmd2 = Fmd.DeserializeXml(_item.FingerPrintID);
                //    CompareResult compareResult = Comparison.Compare(_fmd, 0, _fmd2, 0);
                //    if (compareResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                //    {
                //        _reset = true;
                //        throw new Exception(compareResult.ResultCode.ToString());
                //    }
                //    else
                //    {
                //        if (compareResult.Score < (PROBABILITY_ONE / 100000))
                //        {
                //            //_visitorExist = new MsVisitorHd();
                //            //_visitorExist = _item;
                //            _exist = true;
                //            break;
                //        }
                //        else
                //        {
                //        }
                //    }
                //}
                if (!CheckCaptureResult(captureResult)) return;
                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    this.FingerPictureBox.BackgroundImage = CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height);
                }
                if (_exist)
                {
                    _fgMember = "Y";
                    //MessageBox.Show("Sidik jadi terdaftar sebagai " + _visitorExist.VisitorName);
                }
                else
                {
                    _fgMember = "N";
                }
                //SendMessage(Action.SendMessage, secondFinger.Bytes.ToString() + "Comparison resulted in a dissimilarity score of " + compareResult.Score.ToString() + (compareResult.Score < (PROBABILITY_ONE / 100000) ? " (fingerprints matched)" : " (fingerprints did not match)"));
                //SendMessage(Action.SendMessage, "Place a finger on the reader.");
                //    count = 0;
                //}
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                //SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }
        public bool OpenReader()
        {
            _reset = false;
            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;
            // Open reader
            result = _reader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);
            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result);
                _reset = true;
                return false;
            }
            return _reset;
        }
        public void GetStatus()
        {
            Constants.ResultCode result = _reader.GetStatus();
            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                _reset = true;
                throw new Exception("" + result);
            }
            if ((_reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((_reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                _reader.Calibrate();
            }
            else if ((_reader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + _reader.Status.Status);
            }
        }
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }
                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    throw new Exception("Quality - " + captureResult.Quality);
                }
                return false;
            }
            return true;
        }
        public bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();
                Constants.ResultCode captureResult = _reader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, _reader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    _reset = true;
                    throw new Exception("" + captureResult);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];
            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }
            bmp.UnlockBits(data);
            return bmp;
        }
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            // Activate capture handler
            _reader.On_Captured += new Reader.CaptureCallback(OnCaptured);
            // Call capture
            if (!CaptureFingerAsync())
            {
                return false;
            }
            return true;
        }
        #endregion
