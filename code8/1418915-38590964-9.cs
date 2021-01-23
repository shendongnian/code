    namespace MyProject.Helper{
        public class Helper{
            public bool Validate(string arg1, string arg2)
            {
                bool check
                ...
                return Json(!check ? new { message = "-1" } : new { message = "1" });
            }
        }
    }
