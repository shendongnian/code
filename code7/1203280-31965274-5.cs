     static void Main(string[] args)
        {
          List<string> availableColorsAndSizes = new List<string>();
            string item = string.Empty;
            StringBuilder mediator = new StringBuilder();
            List<string> capries = new List<string>{"Nautica S Blue Bone Woven Pajama Pants",
                                                    "Nike Relay Women's Running Capris - Black, XS",
                                                    "Nautica Mens J-Class Pajama Pants-Small, NAVY",
                                                    "Nautica J-Class Woven Pajama Pant L, Maritime Navy",
                                                    "Nike Legend Tank - Womens - Black/Black",
                                                    "Nike 3PK DF Cushion No Show Tab Socks - Womens - Black/White/Black",
                                                    "Stance Casual Socks - Men's Mahalo, L/XL",
                                                    "Nautica Wrinkle Resistant Dress Pant 30x30, Grey",
                                                    "Nautica Wrinkle Resistant Dress Pant 36x30, Black",
                                                    "Nautica Wrinkle Resistant Dress Pant 33x32, Black",
                                                    "RVCA VA Flipped Box Slim T-Shirt - Short-Sleeve - Men's Bluestone, L",
                                                    "RVCA VA Flipped Box Slim T-Shirt - Short-Sleeve - Men's Bluestone, M",
                                                    "RVCA VA Flipped Box Slim T-Shirt - Short-Sleeve - Men's Bluestone, S",
                                                    };
            foreach (var caprie in capries)
            {
                string[] words = caprie.Split(); //added this for WORD level precison
                foreach (ColorBase colorBase in Enum.GetValues(typeof(ColorBase)))
                {
                    item = Program.GetEnumDescription(colorBase);
                    if (caprie.Contains(item))
                        if (!mediator.ToString().Contains(item + ":"))//just to confirm that it's not being added to the same twice
                            mediator.Append(item + ":");
                }
                foreach (SizeBase sizeBase in Enum.GetValues(typeof(SizeBase)))
                {
                    item = Program.GetEnumDescription(sizeBase);
                    if (caprie.Contains(item))
                        if (!mediator.ToString().Contains(item + ":"))
                            mediator.Append(item);
                }
                mediator.Append("|"); //identifies a pair of 'Color' and 'Size'
            }
            Console.WriteLine("Availabe Parameters");
            string[] colorsAndSizes = mediator.ToString().Split('|');
            foreach (var clrSiz in colorsAndSizes)
            {
                Console.Write("Color : {0}", clrSiz.Split(':')[0]);
                if(clrSiz.Split(':').Length > 1)
                    Console.Write(" ,Size : {0}", clrSiz.Split(':')[1]);
                Console.WriteLine();
            }
     }
