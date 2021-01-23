            /// <summary>
            /// Opens a Word interop lib document.
            /// </summary>
            /// <returns></returns>
            private Word._Document OpenDocument()
            {
                object visible = false;
    
                _document = _wordApp.Documents.Add(_missing, _missing, _missing, visible);
                return _document;
            }
