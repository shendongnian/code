    hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic", 
        Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "rzp_test_26ccbdbfe0e84b80f4ab23e6", "69b2e24411e384f91213f22a")
            )
        )
    );
