    var spellDataEntities = from sbs in spellData.AsEnumerable()
                            select new SpellBookSpell
                            {
                                sbs.Id,
                                sbs.SpellBook_Id,
                                sbs.Spell_Id,
                                Spell = new Spell
                                {
                                    sbs.Spell_Id,
                                    sbs.Spell.Name,
                                    sbs.Spell.Level,
                                    sbs.Spell.Classes
                                }
                            };
