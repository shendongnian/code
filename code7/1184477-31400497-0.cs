    public void savePreset(string doc)
        {
            using (StreamWriter writetext = File.AppendText(doc))
            {
                writetext.Write(player.transform.position.x + ", " + Environment.NewLine );
                writetext.WriteLine(player.transform.position.z + ", ");
                ...
                ...
                writetext.Close();
            }
        }
