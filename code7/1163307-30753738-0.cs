        int[] lung = results.ToArray();
        
        Dictionary<string, Dictionary<string, int>[]> padre = new Dictionary<string, Dictionary<string, int>[]>();
        Dictionary<string, int>[] udemy = new Dictionary<string, int>[2]();
        // populate 
        udemy[0].Add("attributo", lung[0]);
        udemy[1].Add("attributo2", lung[1]);
        // then add
        padre.Add("Lunghezza", udemy);
        string js = JsonConvert.SerializeObject(padre);
        System.Diagnostics.Debug.WriteLine(js);
