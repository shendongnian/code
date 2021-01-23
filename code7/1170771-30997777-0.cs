    string date = txtData.Text;
                    DateTime dt = DateTime.ParseExact(date,"dd/MM/yyyy",System.Globalization.CultureInfo.CurrentCulture);
                    if (DateTime.Compare(dt, DateTime.Now) > 0)
                        MessageBox.Show("data non valida");
                    else
                    {
                        MessageBox.Show("date has been added");
                        string s = txtTitolo.Text + ", " + txtData.Text + ", " + txtDim.Text + ", " + txtFormato.Text + ", " + txtRisoluzione.Text;
                        listVideo.Items.Add(s);
                    }
