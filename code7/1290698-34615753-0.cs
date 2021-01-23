				try
				{
					xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
				}
				catch (Exception ex)
				{
					if (ex.ToString().Contains("0x800401E3 (MK_E_UNAVAILABLE)"))
					{
						xlApp = new Excel.Application();
					}
					else
					{
						throw;
					}
				}
