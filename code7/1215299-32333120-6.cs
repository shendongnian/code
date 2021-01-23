        public static bool IsDateNotAmbigous(this string stringDateTime)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).AsParallel().Select(ci =>
            {
                DateTime parsed = default(DateTime);
                bool success = DateTime.TryParse(stringDateTime, ci, DateTimeStyles.AssumeLocal, out parsed);
                bool test = parsed.Day > 12 || parsed.Day == parsed.Month;
                Trace.WriteLine(String.Format("{0,12}:{1,5}:{2,5}:{3:O}", ci.Name, success, test, parsed));
                if (!success)
                    return -1;
                if (test)
                    return 1;
                return 0;
            }).Where(w=>w>=0).Select(s=>s==1).Aggregate((b, b1) => b || b1);
        }
