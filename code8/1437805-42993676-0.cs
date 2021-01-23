     Connect();
                if (serialPort1.IsOpen)
                {
    
                    int MyInt = ToInt32(lblMixerCase.Text);
                    byte[] b = GetBytes(MyInt);
                    serialPort1.Write(b, 0, 1);
    
                    int MyInt2 = ToInt32(txtRPM.Text);
                    if (MyInt2<=255)
                    {
                        byte[] z = GetBytes(MyInt2);
                        serialPort1.Write(z, 0, 1); //For first 1 byte numbers
                    }
                    else if (MyInt2<=510)
                    {
                        byte[] r = GetBytes(MyInt2);
                        serialPort1.Write(r, 0, 2); for 2 byte numbers
                    }
                    else if (MyInt2<=765)
                    {
                        byte[] a = GetBytes(MyInt2);
                        serialPort1.Write(a, 0, 3); //for 3 byte numbers
                    }
                    else if (MyInt2<=1020)
                    {
                        byte[] q = GetBytes(MyInt2);
                        serialPort1.Write(q, 0, 4); //for 4 byte numbers
                    }
