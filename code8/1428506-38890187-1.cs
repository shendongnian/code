    foreach (var objID in MC.OfType<ID>())
    {
        if (objID.IdNo == 23)
        {
            foreach (var objGreek in objID.Children.OfType<Greek>())
            {
                if (objGreek.GreekType == "Delta")
                {
                    foreach (var objDP in objGreek.Children.OfType<DataPoint>())
                    {
                        if (objDP.DpNo == 14)
                        {
                            double qVal = objDP.Value;
                        }
                    }
                }
            }
        }
    }
