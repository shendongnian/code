            public string ReasonPhrase
            {
                get { return reasonPhrase; }
                set
                {
                    if ((value != null) && ContainsNewLineCharacter(value))
                    {
                        throw new FormatException("The reason phrase must not contain new-line characters.");
                    }
                    CheckDisposed();
    
                    reasonPhrase = value; // It's OK to have a 'null' reason phrase
                }
            }
