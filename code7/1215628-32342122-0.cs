        string[] s = {"[apple]","[banana]","[orange]"} ;
        string new_s = "";
        foreach (string ss in s)
        {                
            new_s += ss.Replace("[", "").Replace("]", ",");                
        }
        //handle extra "," at end of string
        new_s = new_s.Remove(new_s.Length-1);
