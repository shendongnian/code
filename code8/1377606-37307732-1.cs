    public static class EnrollmentExtensions
    {
        public Enrollment ParseEnrollment(this string enrollmentString)
        {
            var enrollment = new Enrollment();
            //Now you can inspect substrings and set the properties
            //on the class before returning it.
            //If the string can't be parsed into an enrollment then
            //you could throw an exception.
        }
    }
