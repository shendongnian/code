    private void resetBtn_Click(object sender, EventArgs e)
    {
        var encoding = Encoding.GetEncoding("iso-8859-1");
        var csvLines = File.ReadAllLines("C:\\Users\\hughesa3\\Desktop\\test environment\\users.csv", encoding);
        for (int i = 0; i < csvLines.Length; i++)
        {
            var values = csvLines[i].Split(',');
            if (values[0].Contains(form2value))
            {
                values[1] = confirmPass.Text;
                using (FileStream stream = new FileStream("C:\\Users\\hughesa3\\Desktop\\test environment\\users.csv", FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream, encoding))
                    {
                        for (int currentLine = 0; currentLine < csvLines.Length; ++currentLine)
                        {
                            if (currentLine == i)
                            {
                                writer.WriteLine(string.Join(",", values));
                            }
                            else
                            {
                                writer.WriteLine(csvLines[i]);
                            }
                        }
                        writer.Close();
                    }
                    stream.Close();
                }
            }
        }
    }
