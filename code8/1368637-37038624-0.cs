    if (!xe.RefName.IsEmpty) {
                    XmlSchemaElement e = (XmlSchemaElement)elements[xe.RefName];
                    if (e == null) {
                        throw new XmlSchemaException(Res.Sch_UndeclaredElement, xe.RefName.ToString(), xe);
                    }  
                    CompileElement(e);
                    if (e.ElementDecl == null) {
                        throw new XmlSchemaException(Res.Sch_RefInvalidElement, xe.RefName.ToString(), xe);
                    }
                    xe.SetElementType(e.ElementSchemaType);
                    decl = e.ElementDecl.Clone();
                }
                else { ...
