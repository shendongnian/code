    else if (CommandEndRex.IsMatch(data))
                {
                    for (var i = _contentBuilder.Length - 1; i >= 0; i--)
                    {
                        if (_contentBuilder[i] == ')')
                        {
                            _contentBuilder.Remove(i, _contentBuilder.Length - i);
                            return;
                        }
                    }
                }
