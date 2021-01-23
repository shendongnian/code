    foreach (OtherFeatures of in FeaturesInfo)
    {
        if (of != null)
        {
            of.NumOtherFeatures = null;
            of.OtherFeaturesDesc = null;
            if (!string.IsNullOrEmpty(View.Panel1.ToString()))
                of.PAN1 = View.Panel1;
            if (!string.IsNullOrEmpty(View.Panel2.ToString()))
                of.PAN2 = View.Panel2;
            if (!string.IsNullOrEmpty(View.Panel3.ToString()))
                of.PAN3 = View.Panel3;
            if (!string.IsNullOrEmpty(View.Panel4.ToString()))
                of.PAN4 = View.Panel4;
            if (!string.IsNullOrEmpty(View.Panel5.ToString()))
                of.PAN5 = View.Panel5;
            break;
        }
    }
