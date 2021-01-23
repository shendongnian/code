    using System.Printing;
			var ps = new PrintServer();
			var queues = ps.GetPrintQueues(
				new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
			// The AMSConfig table has width of 70 for binding to match.
			StringBuilder sb = new StringBuilder();
			foreach (var queue in queues)
			{
				sb.AppendLine( queue.Name );
				if (queue.PropertiesCollection == null)
					continue;
				foreach (System.Collections.DictionaryEntry ppd in queue.PropertiesCollection)
				{
					switch( ppd.Value.ToString() )
					{
						case "System.Printing.IndexedProperties.PrintStringProperty":
							var psp = ppd.Value as System.Printing.IndexedProperties.PrintStringProperty;
							sb.AppendLine(ppd.Key + " : " + psp.Value);
							break;
						case "System.Printing.IndexedProperties.PrintInt32Property":
							var pip = ppd.Value as System.Printing.IndexedProperties.PrintInt32Property;
							sb.AppendLine(ppd.Key + " : " + pip.Value);
							break;
						case "System.Printing.IndexedProperties.PrintTicketProperty":
							var ptp = ppd.Value as System.Printing.IndexedProperties.PrintTicketProperty;
							sb.AppendLine(ppd.Key + " : " + ptp.Value);
							break;
						case "System.Printing.IndexedProperties.PrintBooleanProperty":
							var pbp = ppd.Value as System.Printing.IndexedProperties.PrintBooleanProperty;
							sb.AppendLine(ppd.Key + " : " + pbp.Value);
							break;
						case "System.Printing.IndexedProperties.PrintQueueStatusProperty":
							var pstap = ppd.Value as System.Printing.IndexedProperties.PrintQueueStatusProperty;
							sb.AppendLine(ppd.Key + " : " + pstap.Value);
							break;
						case "System.Printing.IndexedProperties.PrintQueueAttributeProperty":
							var pap = ppd.Value as System.Printing.IndexedProperties.PrintQueueAttributeProperty;
							sb.AppendLine(ppd.Key + " : " + pap.Value);
							break;
						case "System.Printing.IndexedProperties.PrintProcessorProperty":
							var ppp = ppd.Value as System.Printing.IndexedProperties.PrintProcessorProperty;
							sb.AppendLine(ppd.Key + " : " + ppp.Value);
							break;
						case "System.Printing.IndexedProperties.PrintPortProperty":
							var pportp = ppd.Value as System.Printing.IndexedProperties.PrintPortProperty;
							sb.AppendLine(ppd.Key + " : " + pportp.Value);
							break;
						case "System.Printing.IndexedProperties.PrintServerProperty":
							var psvrp = ppd.Value as System.Printing.IndexedProperties.PrintServerProperty;
							sb.AppendLine(ppd.Key + " : " + psvrp.Value);
							break;
						case "System.Printing.IndexedProperties.PrintDriverProperty":
							var pdp = ppd.Value as System.Printing.IndexedProperties.PrintDriverProperty;
							sb.AppendLine(ppd.Key + " : " + pdp.Value);
							break;
					}
				}
				sb.AppendLine("");
				sb.AppendLine("");
			}
			System.IO.File.WriteAllText( "PrinterInfo.txt", sb.ToString());
