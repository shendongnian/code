    public void AddTreatments(string model)
    {
        using (var treatment = this.getTreatmentRepository()) //Or this.getTreatmentRepository.Invoke() - same thing
        {
            ...
        }
    }
