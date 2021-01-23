    using System;
    
    namespace TestConsole
    {
        public static class OutputFormatEnum
        {
            public enum OutputFormat
            {
                DOCX = 0,
                PDF = 1,
                outpdf = 2 //@out/pdf
            }
    
            public static String ConvertToString(this OutputFormat outputFormat)
            {
                return (outputFormat == OutputFormat.outpdf) ? "out/pdf" : Enum.GetName(outputFormat.GetType(), outputFormat);
            }
    
            public static OutputFormat ConverToEnum(this string enumValue)
            {
                OutputFormat outputFormat;
                if (!Enum.TryParse(enumValue, true, out outputFormat))
                {
                    if (enumValue.Equals("out/pdf", StringComparison.InvariantCultureIgnoreCase))
                        outputFormat = OutputFormat.outpdf;
                    else
                        throw new InvalidCastException($"'{enumValue}' is not a valid value for enum OutputFormat");
                }
    
                return outputFormat;
            }
        }
    }
