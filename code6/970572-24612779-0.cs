            string s = @"<NameValueItem>
                            <Text>Test</Text>
                            <Code>Test</Code>
                        </NameValueItem>";
            string newTag = "<Description>TestDescription</Description>";
            string result = Regex.Replace(s, @"(?<=</Code>)", Environment.NewLine + newTag);
