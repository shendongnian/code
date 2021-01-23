		public class AppleAppReceipt
		{
			public class AppleInAppPurchaseReceipt
			{
				public int Quantity;
				public string ProductIdentifier;
				public string TransactionIdentifier;
				public DateTime PurchaseDate;
				public string OriginalTransactionIdentifier;
				public DateTime OriginalPurchaseDate;
				public DateTime SubscriptionExpirationDate;
				public DateTime CancellationDate;
				public int WebOrderLineItemID;
			}
			const int AppReceiptASN1TypeBundleIdentifier = 2;
			const int AppReceiptASN1TypeAppVersion = 3;
			const int AppReceiptASN1TypeOpaqueValue = 4;
			const int AppReceiptASN1TypeHash = 5;
			const int AppReceiptASN1TypeReceiptCreationDate = 12;
			const int AppReceiptASN1TypeInAppPurchaseReceipt = 17;
			const int AppReceiptASN1TypeOriginalAppVersion = 19;
			const int AppReceiptASN1TypeReceiptExpirationDate = 21;
			const int AppReceiptASN1TypeQuantity = 1701;
			const int AppReceiptASN1TypeProductIdentifier = 1702;
			const int AppReceiptASN1TypeTransactionIdentifier = 1703;
			const int AppReceiptASN1TypePurchaseDate = 1704;
			const int AppReceiptASN1TypeOriginalTransactionIdentifier = 1705;
			const int AppReceiptASN1TypeOriginalPurchaseDate = 1706;
			const int AppReceiptASN1TypeSubscriptionExpirationDate = 1708;
			const int AppReceiptASN1TypeWebOrderLineItemID = 1711;
			const int AppReceiptASN1TypeCancellationDate = 1712;
			public string BundleIdentifier;
			public string AppVersion;
			public string OriginalAppVersion; //какую покупали
			public DateTime ReceiptCreationDate;
			public Dictionary<string, AppleInAppPurchaseReceipt> PurchaseReceipts;
			public bool parseAsn1Data(byte[] val)
			{
				if (val == null)
					return false;
				Asn1Parser p = new Asn1Parser();
				var stream = new MemoryStream(val);
				try
				{
					p.LoadData(stream);
				}
				catch (Exception e)
				{
					return false;
				}
				Asn1Node root = p.RootNode;
				if (root == null)
					return false;
				PurchaseReceipts = new Dictionary<string, AppleInAppPurchaseReceipt>();
				parseNodeRecursive(root);
				return !string.IsNullOrEmpty(BundleIdentifier);
			}
			
			private static string getStringFromSubNode(Asn1Node nn)
			{
				string dataStr = null;
				if ((nn.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.OCTET_STRING && nn.ChildNodeCount > 0)
				{
					Asn1Node n = nn.GetChildNode(0);
					switch (n.Tag & Asn1Tag.TAG_MASK)
					{
						case Asn1Tag.PRINTABLE_STRING:
						case Asn1Tag.IA5_STRING:
						case Asn1Tag.UNIVERSAL_STRING:
						case Asn1Tag.VISIBLE_STRING:
						case Asn1Tag.NUMERIC_STRING:
						case Asn1Tag.UTC_TIME:
						case Asn1Tag.UTF8_STRING:
						case Asn1Tag.BMPSTRING:
						case Asn1Tag.GENERAL_STRING:
						case Asn1Tag.GENERALIZED_TIME:
							{
								if ((n.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.UTF8_STRING)
								{
									UTF8Encoding unicode = new UTF8Encoding();
									dataStr = unicode.GetString(n.Data);
								}
								else
								{
									dataStr = Asn1Util.BytesToString(n.Data);
								}
							}
							break;
					}
				}
				return dataStr;
			}
			private static DateTime getDateTimeFromSubNode(Asn1Node nn)
			{
				string dataStr = getStringFromSubNode(nn);
				if (string.IsNullOrEmpty(dataStr))
					return DateTime.MinValue;
				DateTime retval = DateTime.MaxValue;
				try
				{
					retval = DateTime.Parse(dataStr);
				}
				catch (Exception e)
				{
				}
				return retval;
			}
			private static int getIntegerFromSubNode(Asn1Node nn)
			{
				int retval = -1;
				if ((nn.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.OCTET_STRING && nn.ChildNodeCount > 0)
				{
					Asn1Node n = nn.GetChildNode(0);
					if ((n.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.INTEGER)
						retval = (int)Asn1Util.BytesToLong(n.Data);
				}
				return retval;
			}
			private void parseNodeRecursive(Asn1Node tNode)
			{
				bool processed_node = false;
				if ((tNode.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.SEQUENCE && tNode.ChildNodeCount == 3)
				{
					Asn1Node node1 = tNode.GetChildNode(0);
					Asn1Node node2 = tNode.GetChildNode(1);
					Asn1Node node3 = tNode.GetChildNode(2);
					if ((node1.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.INTEGER && (node2.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.INTEGER &&
						(node3.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.OCTET_STRING)
					{
						processed_node = true;
						int type = (int)Asn1Util.BytesToLong(node1.Data);
						switch (type)
						{
							case AppReceiptASN1TypeBundleIdentifier:
								BundleIdentifier = getStringFromSubNode(node3);
								break;
							case AppReceiptASN1TypeAppVersion:
								AppVersion = getStringFromSubNode(node3);
								break;
							case AppReceiptASN1TypeOpaqueValue:
								break;
							case AppReceiptASN1TypeHash:
								break;
							case AppReceiptASN1TypeOriginalAppVersion:
								OriginalAppVersion = getStringFromSubNode(node3);
								break;
							case AppReceiptASN1TypeReceiptExpirationDate:
								break;
							case AppReceiptASN1TypeReceiptCreationDate:
								ReceiptCreationDate = getDateTimeFromSubNode(node3);
								break;
							case AppReceiptASN1TypeInAppPurchaseReceipt:
								{
									if (node3.ChildNodeCount > 0)
									{
										Asn1Node node31 = node3.GetChildNode(0);
										if ((node31.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.SET && node31.ChildNodeCount > 0)
										{
											AppleInAppPurchaseReceipt receipt = new AppleInAppPurchaseReceipt();
											for (int i = 0; i < node31.ChildNodeCount; i++)
											{
												Asn1Node node311 = node31.GetChildNode(i);
												if ((node311.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.SEQUENCE && node311.ChildNodeCount == 3)
												{
													Asn1Node node3111 = node311.GetChildNode(0);
													Asn1Node node3112 = node311.GetChildNode(1);
													Asn1Node node3113 = node311.GetChildNode(2);
													if ((node3111.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.INTEGER && (node3112.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.INTEGER &&
														(node3113.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.OCTET_STRING)
													{
														int type1 = (int)Asn1Util.BytesToLong(node3111.Data);
														switch (type1)
														{
															case AppReceiptASN1TypeQuantity:
																receipt.Quantity = getIntegerFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeProductIdentifier:
																receipt.ProductIdentifier = getStringFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeTransactionIdentifier:
																receipt.TransactionIdentifier = getStringFromSubNode(node3113);
																break;
															case AppReceiptASN1TypePurchaseDate:
																receipt.PurchaseDate = getDateTimeFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeOriginalTransactionIdentifier:
																receipt.OriginalTransactionIdentifier = getStringFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeOriginalPurchaseDate:
																receipt.OriginalPurchaseDate = getDateTimeFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeSubscriptionExpirationDate:
																receipt.SubscriptionExpirationDate = getDateTimeFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeWebOrderLineItemID:
																receipt.WebOrderLineItemID = getIntegerFromSubNode(node3113);
																break;
															case AppReceiptASN1TypeCancellationDate:
																receipt.CancellationDate = getDateTimeFromSubNode(node3113);
																break;
														}
													}
												}
											}
											if (!string.IsNullOrEmpty(receipt.ProductIdentifier))
												PurchaseReceipts.Add(receipt.ProductIdentifier, receipt);
										}
									}
								}
								break;
							default:
								processed_node = false;
								break;
						}
					}
				}
				if (!processed_node)
				{
					for (int i = 0; i < tNode.ChildNodeCount; i++)
					{
						Asn1Node chld = tNode.GetChildNode(i);
						if (chld != null)
							parseNodeRecursive(chld);
					}
				}
			}
		}
