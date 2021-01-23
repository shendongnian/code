    var entries =
        (from course in context.CompletedCourses
         join license in context.Licenses
         on new { course.UserId, course.Course.StateId }
         equals new { license.UserId, license.StateId }
         into licenses
         let licenseNumber = licenses.Select(license => license.LicenseNumber).FirstOrDefault()
         select new { course, licenseNumber });
