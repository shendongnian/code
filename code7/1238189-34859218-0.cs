    var field = new CodeMemberField
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Name = webElement.Name,
                Type = new CodeTypeReference("StringBuilder"))
            };
