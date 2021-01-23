    CObjectId cp_oid = new CObjectId();
                    cp_oid.InitializeFromName(CERTENROLL_OBJECTID.XCN_OID_RSA_challengePwd);
                    byte[] b64__challengePassword = EncodePrintableString("password");
                    ICryptAttribute ChallengeAttributes = new CCryptAttribute();
                    ChallengeAttributes.InitializeFromObjectId(cp_oid);
                    CX509Attribute ChallengeAttribute = new CX509Attribute();
                    ChallengeAttribute.Initialize(cp_oid, EncodingType.XCN_CRYPT_STRING_BASE64_ANY, 
                                                        Convert.ToBase64String(b64__challengePassword));
                    ChallengeAttributes.Values.Add(ChallengeAttribute);
                    objPkcs10.CryptAttributes.Add((CCryptAttribute)ChallengeAttributes);
