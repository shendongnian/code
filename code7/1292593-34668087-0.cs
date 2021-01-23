    public static void SaveTextFile(string StrToSave, string SavePath, Encoding ENCODE)
    {
        //Part1  
        try
        {
            MessageBox.Show(File.ReadAllText(SavePath, ENCODE));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        //Part2
        try
        {
            File.WriteAllText(SavePath, StrToSave, ENCODE);
            MessageBox.Show("Save");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        //Part3
        try
        {
            MessageBox.Show(File.ReadAllText(SavePath, ENCODE));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
