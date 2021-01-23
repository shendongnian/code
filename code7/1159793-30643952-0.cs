    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ServiceCore.Helpers
    {
        /// <summary>
        /// чанкер
        /// </summary>
        public class ChunkReader<T>
        {
            #region Declarations
    
            private List<T> _data;                  // данные
            private int _pos;                       // позиция
    
            #endregion
            #region Properties
    
            /// <summary>
            /// число записей
            /// </summary>
            public int Count { get { return _data.Count; } }
    
            /// <summary>
            /// размер чанка
            /// </summary>
            public int ChunkSize { get; set; }
    
            /// <summary>
            /// число чанков
            /// </summary>
            public int ChunksCount
            {
                get
                {
                    int count = _data.Count;
                    return count == 0 ? 0 : (int)Math.Ceiling((double)count / (double)ChunkSize);
                }
            }
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            /// конструктор
            /// </summary>
            public ChunkReader()
            {
                ChunkSize = 20;
            }
    
            /// <summary>
            /// конструктор
            /// </summary>
            /// <param name="data"> данные </param>
            public ChunkReader(List<T> data)
                : this()
            {
                Init(data);
            }
    
            /// <summary>
            /// конструктор
            /// </summary>
            /// <param name="data"> данные </param>
            /// <param name="chunkSize"> размер чанка </param>
            public ChunkReader(List<T> data, int chunkSize)
                : this()
            {
                ChunkSize = chunkSize;
                Init(data);
            }
    
            #endregion
    
            #region Private methods
            #endregion
            #region Protected methods
            #endregion
            #region Public methods
    
            /// <summary>
            /// инициализация
            /// </summary>
            /// <param name="data"> данные </param>
            public void Init(List<T> data)
            {
                _data = data;
                _pos = 0;
            }
    
            /// <summary>
            /// сбросить текущую позицию
            /// </summary>
            public void Reset()
            {
                _pos = 0;
            }
    
            /// <summary>
            /// прочитать очередной чанк
            /// </summary>
            /// <param name="chunk"> чанк </param>
            /// <returns></returns>
            public bool Read(out List<T> chunk)
            {
                int count = _data.Count;
                if (_pos >= count)
                {
                    chunk = null;
                    return false;
                }
                else
                {
                    chunk = new List<T>();
                    int last = _pos + ChunkSize;
                    for (int i = _pos; i < count && i < last; i++, _pos++)
                    {
                        chunk.Add(_data[_pos]);
                    }
                    return true;
                }
            }
    
            #endregion
        }
    }
