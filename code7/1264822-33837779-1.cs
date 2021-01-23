    private XmlElementSyntax CreateParameter(ParameterSyntax parameterSyntax)
    {
      var identifier = SyntaxFactory.Identifier(parameterSyntax.Identifier.Text);
      var attribute = SyntaxFactory.XmlNameAttribute(
          SyntaxFactory.XmlName("name"),
          SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
          SyntaxFactory.IdentifierName(identifier),
          SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken));
      var startTag = SyntaxFactory.XmlElementStartTag(SyntaxFactory.XmlName("param"))
        .WithAttributes(new SyntaxList<XmlAttributeSyntax>().Add(attribute));
      var endTag = SyntaxFactory.XmlElementEndTag(SyntaxFactory.XmlName("param"));
      return SyntaxFactory.XmlElement(startTag, new SyntaxList<XmlNodeSyntax>(), endTag)
                          .NormalizeWhitespace();
    }
