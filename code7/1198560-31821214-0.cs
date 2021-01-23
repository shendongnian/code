    partial void MeanFemale_Compute(ref string result)
    {
        // Set result to the desired field value
        int totalAge = 0;
        int count = 0;
        foreach (InsuranceQuotation i in this.DataWorkspace.ApplicationData.InsuranceQuotations)
        {
            if(i.Female == true)
            {
                totalAge += i.mAge;
                count++;
            }
        }
        if (count != 0)
        {
            result = (totalAge / count).ToString();
        }
    }
