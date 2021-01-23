    using System;
    using System.Collections.Generic;
    
    using WebMarkupMin.Core;
    
    namespace WebMarkupMin.Sample.ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string htmlInput = @"<!DOCTYPE html>
    <html>
        <head>
            <meta charset=""utf-8"" />
            <title>The test document</title>
            <link href=""favicon.ico"" rel=""shortcut icon"" type=""image/x-icon"" />
            <meta name=""viewport"" content=""width=device-width"" />
            <link rel=""stylesheet"" type=""text/css"" href=""/Content/Site.css"" />
        </head>
        <body>
            <p>Lorem ipsum dolor sit amet...</p>
    
            <script src=""http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js""></script>
            <script>
                (window.jquery) || document.write('<script src=""/Scripts/jquery-1.9.1.min.js""><\/script>');
            </script>
        </body>
    </html>";
    
                var htmlMinifier = new HtmlMinifier();
    
                MarkupMinificationResult result = htmlMinifier.Minify(htmlInput,
                    generateStatistics: true);
                if (result.Errors.Count == 0)
                {
                    MinificationStatistics statistics = result.Statistics;
                    if (statistics != null)
                    {
                        Console.WriteLine("Original size: {0:N0} Bytes",
                            statistics.OriginalSize);
                        Console.WriteLine("Minified size: {0:N0} Bytes",
                            statistics.MinifiedSize);
                        Console.WriteLine("Saved: {0:N2}%",
                            statistics.SavedInPercent);
                    }
                    Console.WriteLine("Minified content:{0}{0}{1}",
                        Environment.NewLine, result.MinifiedContent);
                }
                else
                {
                    IList<MinificationErrorInfo> errors = result.Errors;
    
                    Console.WriteLine("Found {0:N0} error(s):", errors.Count);
                    Console.WriteLine();
    
                    foreach (var error in errors)
                    {
                        Console.WriteLine("Line {0}, Column {1}: {2}",
                            error.LineNumber, error.ColumnNumber, error.Message);
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }
        }
    }
