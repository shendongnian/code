    public static void Main(string[] args)
    {
        string json = @"{
                        'Data': {
                        'namelist': [
                          {
                            'name': 'Elson Mon',
                            'Information': {
                              'Age': 45.0,
                              'Height': 168.7,
                              'Weight': 75.4,
                              'Birthdate': '1992-03-03'
                            },
                            'Married Status': 'Single'
                          }
                        ]
                        }
                        }";
    
        RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
    }
