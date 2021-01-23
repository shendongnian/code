    void HandlePanel(string panel, Action<OtherFeatures> action)
    {
        if (!string.IsNullOrEmpty(panel))
        {
            foreach (var of in FeaturesInfo)
            {
                if (of != null)
                {
                    action(of);
                    of.NumOtherFeatures = null;
                    of.OtherFeaturesDesc = null;
                    break;
                }
            }
        }
    }
    ...
    HandlePanel(View.Panel1.ToString(), of => of.PAN1 = View.Panel1);
    HandlePanel(View.Panel2.ToString(), of => of.PAN2 = View.Panel2);
    HandlePanel(View.Panel3.ToString(), of => of.PAN3 = View.Panel3);    
    HandlePanel(View.Panel4.ToString(), of => of.PAN4 = View.Panel4);
    ....
