     if (textBox1.Text.Length != 0)
                {
    
                    var numePrenume = textBox1.Text.Trim().Split(' ');
                    if (numePrenume.Length >= 1)
                    {
                        var nume = numePrenume[0];
                        var prenume = numePrenume[1];
    
                        if (nume.Length > 0 || prenume.Length > 0)
                        {
                            var connString = @"Data Source=C:\Users\Andrei\Documents\Visual Studio 2010\Projects\Stellwag\Stellwag\Angajati.sdf";
                            using (var conn = new SqlCeConnection(connString))
                            {
                            }
                        }
                    }
                    else
                        // some code here
                }
