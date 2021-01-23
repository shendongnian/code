            string message = "ABCD E FGHI JKLMNOP QRSTU VWXYz Apt NUMBER1234 Block A";
            string firstline ="";
            string secondline="";
            if(message.Length > 30)
            {
                for(int i = 30; i > 0;)
                {
                    if(message[i] == ' ')
                    {
                        firstline = message.Substring(0, i);
                        secondline = message.Substring(i + 1);
                        break;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
