        Dim x1 As XElement
        Dim x2 As XElement
        x1 = <APPLICATION>
                 <AC>
                     <CLASS Name="Hello1" Capt="do1"/>
                     <CLASS Name="Hello2" Capt="do2"/>
                     <CLASS Name="Hello5" Capt="do5"/>
                     <CLASS Name="Hello8" Capt="do8"/>
                 </AC>
                 <BO>
                     <ITEM Id="1" DefaultValue="name1"/>
                     <ITEM Id="3" DefaultValue="name3"/>
                     <ITEM Id="11" DefaultValue="name11"/>
                     <ITEM Id="12" DefaultValue="name12">
                         <VAL>
                             <REASON Id="Job1" SecondOne="Hallo"/>
                         </VAL>
                     </ITEM>
                 </BO>
             </APPLICATION>
        x2 = <APPLICATION>
                 <AC>
                     <CLASS Name="Hello1" Capt="dodo1"/>
                     <CLASS Name="Hello2" Capt="dodo2"/>
                     <CLASS Name="Hello3" Capt="dodo3"/>
                     <CLASS Name="Hello9" Capt="dodo9"/>
                 </AC>
                 <CARS Wheel="Fore" Default="45x255xZ"/>
                 <CARS Wheel="BACK" Default="45x255xZ"/>
                 <CARS Wheel="SPARE" Default="45x255xZ"/>
                 <BO>
                     <ITEM Id="1" DefaultValue="namename1"/>
                     <ITEM Id="3" DefaultValue=""/>
                     <ITEM Id="9" DefaultValue="name11"/>
                     <ITEM Id="10" DefaultValue="name12">
                         <VAL>
                             <REASON Id="Job1" SecondOne="Hallo"/>
                         </VAL>
                     </ITEM>
                 </BO>
             </APPLICATION>
        Dim ie As IEnumerable(Of XElement)
        ie = From x1id In x1.<BO>.<ITEM>, x2id In x2.<BO>.<ITEM>
             Where x1id.@Id = x2id.@Id
             Select x2id
        If ie.Count > 0 Then
            ie.Remove()
            x1.<AC>.LastOrDefault.Add(x2.<AC>.Elements)
            x1.<AC>.LastOrDefault.AddAfterSelf(x2.<CARS>)
            x1.<BO>.LastOrDefault.Add(x2.<BO>.Elements)
        End If
