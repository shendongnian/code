     LayerTable _LayerTable = acTrans.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                             foreach (ObjectId _LayerTableId in _LayerTable)
                             {
                                 LayerTableRecord _LayerTableRecord =
                                            (LayerTableRecord)acTrans.GetObject(_LayerTableId,
                                                                OpenMode.ForWrite);
                                 if (_LayerTableRecord.IsFrozen)
                                 {
                                     _LayerTableRecord.IsPlottable = false;
                                 }
                             }
