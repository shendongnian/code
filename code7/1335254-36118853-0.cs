                catch(Exception)
                {                     
                    // Has the user specified to redirect the row?
                    if (input.ErrorRowDisposition == DTSRowDisposition.RD_RedirectRow)
                    {
                        // Yes, get the error code
                        int DTS_E_ERRORTRIGGEREDREDIRECTION = -1;
                        unchecked
                        {
                            DTS_E_ERRORTRIGGEREDREDIRECTION = (int)0xC020401E;
                        }
                        
                        // Direct the row to the error output
                        buffer.DirectErrorRow(intErrorOutputID, DTS_E_ERRORTRIGGEREDREDIRECTION, intErrorColumnIndex);
                    }
                    else if (input.ErrorRowDisposition == DTSRowDisposition.RD_FailComponent || input.ErrorRowDisposition == DTSRowDisposition.RD_NotUsed)
                    {
                        // No, the user specified to fail the component, or the error row disposition was not set
                        throw new Exception("An error occurred, and the DTSRowDisposition is either not set or is set to fail component.");
                    }
                    else
                    {
                        // No, the user specified to ignore the failure so direct the row to the default output
                        buffer.DirectRow(intDefaultOutputID);
                    }
                }
