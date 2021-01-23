    public MyReturnModel ValidateValue(float value)
    {
        //function logic here 
        bool result = value == VALID_VALUE;
        string msg = result ? "valud is valid" : "value is invalid";
        return new MyReturnModel { Success = result, ErrorOrSuccessMessage = msg }
    }
