    Parallel.ForEach(list,(item) =>
    {
        emailBody = emailBody.Replace("<Item1>", list.FirstOrDefault().Item1);
        emailBody = emailBody.Replace("<Item2>", list.FirstOrDefault().Item2);
        emailBody = emailBody.Replace("<Item3>", list.FirstOrDefault().Item3);
        emailBody = emailBody.Replace("<Item4>", list.FirstOrDefault().Item4);
        emailBody = emailBody.Replace("<Item5>", list.FirstOrDefault().Item5);
        emailBody = emailBody.Replace("<Item6>", list.FirstOrDefault().Item6);
    });
