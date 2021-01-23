     using System;
     using System.Collections;
     using System.Collections.Generic;
     using System.Data.OleDb;
     using System.IO;
     using System.Text;
     namespace Catfood.Shapefile
     { 
    /// <summary>
    /// 
    /// </summary>
    public class ShpParser : IDisposable, IEnumerator<Shape>, IEnumerable<Shape>
    {
        private bool _disposed;
        private bool _opened;
        private int _currentIndex;
        private int _count;
        private RectangleD _boundingBox;
        private ShapeType _type;
        private int _currentPosition;
        private FileStream _mainStream;
        private Header _mainHeader;
        /// <summary>
        /// 
        /// </summary>
        public ShpParser()
        {
            _currentIndex = -1;
            _currentPosition = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public ShpParser(string path)
            : this()
        {
            Open(path);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private void Open(string path)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("ShpParser");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("shp file not found", path);
            }
            _mainStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (_mainStream.Length < Header.HeaderLength)
            {
                throw new InvalidOperationException("Shapefile main file does not contain a valid header");
            }
            // read in and parse the headers
            var headerBytes = new byte[Header.HeaderLength];
            _mainStream.Read(headerBytes, 0, Header.HeaderLength);
            _mainHeader = new Header(headerBytes);
            _type = _mainHeader.ShapeType;
            _boundingBox = new RectangleD(_mainHeader.XMin, _mainHeader.YMin, _mainHeader.XMax, _mainHeader.YMax);
            _currentPosition = Header.HeaderLength;
            _count = _mainHeader.FileLength * 2; // FileLength return the size of file in words (16 bytes)
            _opened = true;
        }
        #region IDisposable Members
        /// <summary>
        /// Close the Shapefile. Equivalent to calling Dispose().
        /// </summary>
        public void Close()
        {
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool canDisposeManagedResources)
        {
            if (!_disposed)
            {
                if (canDisposeManagedResources)
                {
                    if (_mainStream != null)
                    {
                        _mainStream.Close();
                        _mainStream = null;
                    }
                }
                _disposed = true;
                _opened = false;
            }
        }
        #endregion
        public bool MoveNext()
        {
            if (_disposed) throw new ObjectDisposedException("ShpParser");
            if (!_opened) throw new InvalidOperationException("ShpParser not open.");
            if (_currentPosition < (_count - 1))
            {
                // try to read the next database record
               return true;
            }
            else
            {
                // reached the last shape
                return false;
            }
        }
        public void Reset()
        {
            if (_disposed) throw new ObjectDisposedException("ShpParser");
            if (!_opened) throw new InvalidOperationException("ShpParser not open.");
            _currentIndex = -1;
        }
        public Shape Current
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException("ShpParser");
                if (!_opened) throw new InvalidOperationException("ShpParser not open.");
              
                //get recordheader;
                var recordheader = new byte[8];
              
                _mainStream.Read(recordheader, 0, recordheader.Length);
           
             
                int contentOffsetInWords = EndianBitConverter.ToInt32(recordheader, 0, ProvidedOrder.Big);
                int contentLengthInWords = EndianBitConverter.ToInt32(recordheader, 4, ProvidedOrder.Big);
                _mainStream.Seek(_currentPosition , SeekOrigin.Begin); // back to header of record 
                int bytesToRead = (contentLengthInWords * 2) + 8;
                byte[] shapeData = new byte[bytesToRead];
                _currentPosition += bytesToRead;
                _mainStream.Read(shapeData, 0, bytesToRead);
                return ShapeFactory.ParseShape(shapeData , null);
             //  return null;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException("ShpParser");
                if (!_opened) throw new InvalidOperationException("ShpParser not open.");
                return this.Current;
            }
        }
        public IEnumerator<Shape> GetEnumerator()
        {
            return (IEnumerator<Shape>)this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator)this;
        }
    }
