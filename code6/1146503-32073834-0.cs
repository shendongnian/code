    var document = new HtmlToPdfDocument
    {
        GlobalSettings =
        {
            ProduceOutline = true,
            DocumentTitle = "Pretty Websites",
            PaperSize = PaperKind.A4, // Implicit conversion to PechkinPaperSize
            Margins =
            {
                All = 1.375,
                Unit = Unit.Centimeters
            }
        },
        Objects = {
            new ObjectSettings { HtmlText = "<h1>Pretty Websites</h1><p>This might take a bit to convert!</p>" },
            new ObjectSettings { PageUrl = "www.google.com" }
        }
    };
