    // out message
    string _msg = String.Empty;
    
    // sample array of Name/Birthday
    string[,] _bd = { 
                        { "Tom", "03/26/2016" }, 
                        { "Gary", "06/27/2016" }, 
                        { "Anna", "04/30/2016" } 
                    };
    for (int i = 0; i < _bd.GetLength(0); i++)
    {
        if (DateTime.Today == DateTime.Parse(_bd[i, 1]))
        {
            // output message containing list of names
            _msg += _bd[i, 0] + ",";
        }
    }
    if (!String.IsNullOrEmpty(_msg)) MessageBox.Show("Hello" +_msg);
