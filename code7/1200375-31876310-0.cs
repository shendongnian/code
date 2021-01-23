     foreach (var item in lines)
                {
                    if (item.StartsWith("127") || item.StartsWith("192"))                
                        return new ValidationResult("IpAddress cant be saved");
                    
    
                    if (String.IsNullOrWhiteSpace(IpCondition.IpAddress))
                        return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
    
                    IPAddress address;
    
                    if (IPAddress.TryParse(item, out address))
                    {
                        continue;
                    }
                    else
                    {
                        return new ValidationResult("IpAddress cant be saved");
                    }
                }
               
