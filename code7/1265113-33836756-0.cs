    foreach (var of in FeaturesInfo)
    {
        if (of != null)
        {
            TestAndSet(View.Panel1.ToString(), text => of.PAN1 = text);
            TestAndSet(View.Panel2.ToString(), text => of.PAN2 = text);
            TestAndSet(View.Panel3.ToString(), text => of.PAN3 = text);
            of.NumOtherFeatures = null;
            of.OtherFeaturesDesc = null;
            break;
        }
    }
    ....
    private void TestAndSet(String panel, Action<string> setAction)
    {
        if (!string.IsNullOrEmpty(panel))
        {
           setAction(panel);
        }        
    }
