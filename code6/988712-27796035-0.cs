    var stringVal = new string(new char[] { System.Convert.ToChar(0x1b) /* ESC */, 
                                            'A', 
                                            System.Convert.ToChar(51) });
    data = Encoding.Default.GetBytes(stringVal + NewLine);
    connection.Write(data);
