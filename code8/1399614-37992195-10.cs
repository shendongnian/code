    var enzymeSequences=(from seq in sequences
                            from enzyme in seq.Enzymes
                            let pair = new { seq.Name, enzyme }
                            group pair by enzyme into enzymeSeqs
                            select enzymeSeqs);
    var enzymeDict= enzymeSequences.ToDictionary(
                            grp => grp.Key, 
                            grp=> grp.Select(pair=>pair.Name)
                                        .ToArray());
    var matches = enzymeDict["AGG"];
    Console.WriteLine(String.Join(" ", matches));
