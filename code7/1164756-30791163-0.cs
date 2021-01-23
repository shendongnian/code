    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets
        xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
        <CodeSnippet Format="1.0.0">
            <Header>
                <Title>MyProp</Title>
                <Author>ryanyuyu</Author>
                <Description>Auto get/set property</Description>
                <Shortcut>myprop</Shortcut>
            </Header>
            <Snippet>
                <Declarations>
                    <Literal>
                        <ID>propName</ID>
                        <Default>MyProperty</Default>
                        <ToolTip>The name of the property.</ToolTip>
                    </Literal>
                </Declarations>
                <Code Language="CSharp">
                    <![CDATA[
            public string $propName$
            {
                get { return _getValue(); }
                set { _setValue(value); }
            }
                ]]>
                </Code>
            </Snippet>
        </CodeSnippet>
    </CodeSnippets>
