    public static bool tryValoreNumerico(object valore, out decimal valoreRestituito)
		{
			decimal n;			
			string testoNormalizzato;
			valoreRestituito = 0;
			// normalizzazione
			if (valore.ToString().Contains(",") && valore.ToString().Contains("."))
			{
				if (valore.ToString().IndexOf(".") < valore.ToString().IndexOf(","))
				{
					testoNormalizzato = valore.ToString().Replace(".", "");
				}
				else
				{
					testoNormalizzato = valore.ToString().Replace(",", "");
				}
			}
			else
			{
				if ((valore.ToString().Length - valore.ToString().Replace(",", "").Length) > 1)
				{
					string[] pezzi = valore.ToString().Split(',');
					for (int i = 1; i < pezzi.Length; i++ )
					{
						if (pezzi[i].Length != 3)
							return false;
					}
					testoNormalizzato = valore.ToString().Replace(",", "");
				}
				else if ((valore.ToString().Length - valore.ToString().Replace(".", "").Length) > 1)
				{
					string[] pezzi = valore.ToString().Split('.');
					for (int i = 1; i < pezzi.Length; i++)
					{
						if (pezzi[i].Length != 3)
							return false;
					}
					testoNormalizzato = valore.ToString().Replace(".", "");
				}
				else
					testoNormalizzato = valore.ToString();
			}
			testoNormalizzato = testoNormalizzato.Replace(",", ".");
			if (decimal.TryParse(testoNormalizzato, out n) && testoNormalizzato == Convert.ToDecimal(testoNormalizzato, new CultureInfo("en-US")).ToString().Replace(",", "."))
			{
				valoreRestituito = Convert.ToDecimal(testoNormalizzato, new CultureInfo("en-US"));
			}
			return decimal.TryParse(testoNormalizzato, out n) && testoNormalizzato == Convert.ToDecimal(testoNormalizzato, new CultureInfo("en-US")).ToString().Replace(",", ".");
		}
