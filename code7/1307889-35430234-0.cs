                _hContext = new SCardContext();
                _hContext.Establish(SCardScope.System);
                // Create a _reader object using the existing context
                _reader = new SCardReader(_hContext);
                // Connect to the card
                if (readerName == null || readerName == String.Empty)
                {
                    // Retrieve the list of Smartcard _readers
                    string[] szReaders = _hContext.GetReaders();
                    if (szReaders.Length <= 0)
                        throw new PCSCException(SCardError.NoReadersAvailable,
                            "Could not find any Smartcard _reader.");
                    _err = _reader.Connect(szReaders[0],
                                SCardShareMode.Shared,
                                SCardProtocol.T0 | SCardProtocol.T1);
                    CheckErr(_err);
                 }
