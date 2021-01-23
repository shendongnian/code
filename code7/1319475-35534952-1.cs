            protected override void OnChanged(string propertyName)
            {
                if (propertyName == "Gender")
                {
                    if(Titles==null) 
                    {
                        Titles = new BindingList<string>();
                    }
                    Titles.Clear();
                    if (Gender == Gender.Female)
                    {
                        //Titles.AddRange(new[] { "Ms", "Mrs" });
                        Titles.Add("Ms");
                        Titles.Add("Mrs");
                    }
                    else
                    {
                        Titles.Add("Mr");
                        Titles.Add("Sir");
                    }
                }
                base.OnChanged(propertyName);
            }
