    void fill(PdfReader reader, AcroFields acroFields)
    {
        IDictionary<string, AcroFields.Item> fields = new LinkedDictionary<string, AcroFields.Item>();
        PdfDictionary top = (PdfDictionary)PdfReader.GetPdfObjectRelease(reader.Catalog.Get(PdfName.ACROFORM));
        if (top == null)
            return;
        PdfBoolean needappearances = top.GetAsBoolean(PdfName.NEEDAPPEARANCES);
        if (needappearances == null || !needappearances.BooleanValue)
            acroFields.GenerateAppearances = true;
        else
            acroFields.GenerateAppearances = false;
        PdfArray arrfds = (PdfArray)PdfReader.GetPdfObjectRelease(top.Get(PdfName.FIELDS));
        if (arrfds == null || arrfds.Size == 0)
            return;
        System.Reflection.FieldInfo valuesField = typeof(AcroFields.Item).GetField("values", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        System.Reflection.FieldInfo widgetsField = typeof(AcroFields.Item).GetField("widgets", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        System.Reflection.FieldInfo widgetRefsField = typeof(AcroFields.Item).GetField("widget_refs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        System.Reflection.FieldInfo mergedField = typeof(AcroFields.Item).GetField("merged", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        System.Reflection.FieldInfo pageField = typeof(AcroFields.Item).GetField("page", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        System.Reflection.FieldInfo tabOrderField = typeof(AcroFields.Item).GetField("tabOrder", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        for (int j = 0; j < arrfds.Size; ++j)
        {
            PdfDictionary annot = arrfds.GetAsDict(j);
            if (annot == null)
            {
                PdfReader.ReleaseLastXrefPartial(arrfds.GetAsIndirectObject(j));
                continue;
            }
            if (!PdfName.WIDGET.Equals(annot.GetAsName(PdfName.SUBTYPE)))
            {
                PdfReader.ReleaseLastXrefPartial(arrfds.GetAsIndirectObject(j));
                continue;
            }
            PdfArray kids = (PdfArray)PdfReader.GetPdfObjectRelease(annot.Get(PdfName.KIDS));
            if (kids != null)
                continue;
            PdfDictionary dic = new PdfDictionary();
            dic.Merge(annot);
            PdfString t = annot.GetAsString(PdfName.T);
            if (t == null)
                continue;
            String name = t.ToUnicodeString();
            if (fields.ContainsKey(name))
                continue;
            AcroFields.Item item = new AcroFields.Item();
            fields[name] = item;
            ((List<PdfDictionary>)valuesField.GetValue(item)).Add(dic); // item.AddValue(dic);
            ((List<PdfDictionary>)widgetsField.GetValue(item)).Add(dic); // item.AddWidget(dic);
            ((List<PdfIndirectReference>)widgetRefsField.GetValue(item)).Add(arrfds.GetAsIndirectObject(j)); //item.AddWidgetRef(arrfds.GetAsIndirectObject(j)); // must be a reference
            ((List<PdfDictionary>)mergedField.GetValue(item)).Add(dic); // item.AddMerged(dic);
            ((List<int>)pageField.GetValue(item)).Add((int)-1); // item.AddPage(-1);
            ((List<int>)tabOrderField.GetValue(item)).Add((int)-1); // item.AddTabOrder(-1);
        }
        System.Reflection.FieldInfo fieldsField = typeof(AcroFields).GetField("fields", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        fieldsField.SetValue(acroFields, fields);
    }
