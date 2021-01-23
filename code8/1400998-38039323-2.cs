        Dim doc As XElement
        ' to load   doc = XElement.Load("path/URI here")
        ' for testing
        doc = <WordDefinition>
                  <Word>analyses</Word>
                  <Definitions>
                      <Definition>
                          <Word>analyses</Word>
                          <Dictionary>
                              <Id>wn</Id>
                              <Name>WordNet (r) 2.0</Name>
                          </Dictionary>
                          <WordDefinition>analyses
         See {analysis}
      </WordDefinition>
                      </Definition>
                      <Definition>
                          <Word>analyses</Word>
                          <Dictionary>
                              <Id>wn</Id>
                              <Name>WordNet (r) 2.0</Name>
                          </Dictionary>
                          <WordDefinition>analysis
     n 1: an investigation of the component parts of a whole and their
          relations in making up the whole
      </WordDefinition>
                      </Definition>
                  </Definitions>
              </WordDefinition>
        'get the last WordDefinition
        Dim lastDef As XElement = doc...<WordDefinition>.LastOrDefault
