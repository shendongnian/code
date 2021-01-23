    var generatedValue = 0;
    var firstAdmission = context.Admission.FirstOrDefault();
    if(firstAdmission == null)
        return;
    if(!firstAdmission.AdmissionNo.HasValue)
        generatedValue = 123; // Whatever logic u have to generate a value
    else
        generatedValue= AdmissionNo.Value + 1;
