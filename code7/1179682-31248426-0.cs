    /// <summary>
            /// Ensure any given wave file path that the file matches 
            /// with default or base format [16bit 8kHz Mono]
            /// </summary>
            /// <param name="strPath">Wave file path</param>
            /// <returns>True/False</returns>
            public bool Validate(string strPath)
            {
                if (strPath == null) strPath = "";
                if (strPath == "") return false;
        
                clsWaveProcessor wa_val = new clsWaveProcessor();
                wa_val.WaveHeaderIN(strPath);
                if (wa_val.BitsPerSample != BIT_PER_SMPL) return false;
                if (wa_val.Channels != CHNL) return false;
                if (wa_val.SampleRate != SMPL_RATE) return false;
                return true;
            }
        
            /// <summary>
            /// Compare two wave files to ensure both are in same format
            /// </summary>
            /// <param name="Wave1">ref. to processor object</param>
            /// <param name="Wave2">ref. to processor object</param>
            /// <returns>True/False</returns>
            private bool Compare(ref clsWaveProcessor Wave1, ref clsWaveProcessor Wave2)
            {
                if (Wave1.Channels != Wave2.Channels) return false;
                if (Wave1.BitsPerSample != Wave2.BitsPerSample) return false;
                if (Wave1.SampleRate != Wave2.SampleRate) return false;
                return true;
            }
