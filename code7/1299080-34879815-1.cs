            // Form has a panel, set back color to Sheet1.H2 color
            panel1.BackColor = demoExcel.ForeColor;
            // Translate the color to HTML
            var htmlColor = System.Drawing.ColorTranslator.ToHtml(demoExcel.ForeColor);
            Console.WriteLine(htmlColor.ToString());
