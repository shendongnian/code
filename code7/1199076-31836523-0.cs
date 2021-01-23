     public class Utitlity
        {
            public static SemaphoreSlim semaphore = new SemaphoreSlim(300, 320);
            public static char[] TokensSeparator = "|,".ToCharArray();
            public async Task Parse(Stream content, Action<Trade> parseCallback)
            {
                await Task.Run(async () =>
                {
                    using (var streamReader = new StreamReader(content))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (String.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }
    
                            var tokens = line.Split(TokensSeparator);
                            if (!tokens.Any() || tokens.Count() != 6)
                            {
                                continue;
                            }
                            await semaphore.WaitAsync();
                            await Task.Run(() =>
                            {
                                var trade = new Trade
                            {
                                Id = Int32.Parse(tokens[0]),
                                MktPrice = Decimal.Parse(tokens[1], CultureInfo.InvariantCulture),
                                Notional = Decimal.Parse(tokens[2], CultureInfo.InvariantCulture),
                                Quantity = Int64.Parse(tokens[3]),
                                TradeDate = DateTime.Parse(tokens[4], CultureInfo.InvariantCulture),
                                TradeType = tokens[5]
                            };
                                parseCallback(trade);
    
                            });
                            semaphore.Release();
                        }
                    }
                });
            }
        }
    
        public class Trade
        {
            public int Id { get; set; }
            public decimal MktPrice { get; set; }
            public decimal Notional { get; set; }
            public long Quantity { get; set; }
            public DateTime TradeDate { get; set; }
            public string TradeType { get; set; }
    
    
        }
