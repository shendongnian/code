		public static void ReleaseComObject (object o)
		{
			try
			{
				if (o != null)
				{
					if (Marshal.IsComObject(o))
					{
						Marshal.ReleaseComObject(o);
					}
				}
			}
			finally
			{
				o = null;
			}
		}
