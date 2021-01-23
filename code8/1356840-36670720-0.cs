    string message = "Hello Stack overflow!";
    string key = "uCEgauAQDWGDkcclGe1rNV6V77xtizuemhgxzM5nqO4=";
    string nonce = "+RTDstWX1Wps5/btQzSMHWBqHU9s6iqq";
    byte[] box = Sodium.SecretBox.Create(Encoding.UTF8.GetBytes(message), 
                                                 Convert.FromBase64String(nonce), 
                                                 Convert.FromBase64String(key));
    byte[] boxWithoutAuthenticationTag = new byte[box.Length - 16];
    Array.Copy(box, 16, boxWithoutAuthenticationTag, 0, box.Length - 16);
    Console.WriteLine(Convert.ToBase64String(boxWithoutAuthenticationTag));
