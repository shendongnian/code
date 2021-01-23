    // GetCountOfKeyTransferRecipients
                GetMessageParam( hMsg, Win32.CMSG_RECIPIENT_COUNT_PARAM, out pRecipientsCount );
                Int32 recipientsCount = (Int32) Marshal.ReadInt32( pRecipientsCount.DangerousGetHandle() );
                Logger.Log( "Recipientek száma:" + recipientsCount.ToString(), Logger.Level.ERROR );
                Boolean succes = false;
                Int32 recipientIndex = 0;
                for (recipientIndex = 0; recipientIndex < recipientsCount; recipientIndex++)
                {
                    succes = GetCertificateFromStore( hMsg, recipientIndex, out KeyProvInfo ); // try-catch is inside...
                    if (succes)
                    {
                        break;
                    }
                }
                if (!succes)
                {
                    throw new Exception( "Get message certificate failed! See previous errors in the log file." );
                }
