             if(!reader.Read())
             //Your message 
             else
             {
                do
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append(" | ");
                        }
                        sb.Append(reader[i].ToString());
                    }
                    sb.AppendLine();
                    ClientIDCell.Text = reader[0].ToString();
                    NNNCell.Text = reader[1].ToString();
                    FirstNameCell.Text = reader[2].ToString();
                    SurnameCell.Text = reader[3].ToString();
                    DobCell.Text = reader[4].ToString();
                    GenderCell.Text = reader[5].ToString();
                } while (reader.Read());
            }
