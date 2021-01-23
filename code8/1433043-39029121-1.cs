    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentAssertions;
    using NUnit.Framework;
    
    namespace StackOverflow
    {
        [TestFixture]
        public class Class1
        {
            private Dictionary<string, Group> _emailGroups;
            private Dictionary<string, Group> _telGroups;
            private Dictionary<string, Group> _postcodeGroups;
    
            private void CreateGroup(Entry entry)
            {
                var group = new Group(entry);
    
                if (group.Email != null)
                    _emailGroups[group.Email] = group;
    
                if (group.Tel != null)
                    _telGroups[group.Tel] = group;
    
                if (group.PostCode != null)
                    _postcodeGroups[group.PostCode] = group;
            }
    
            private void CombineGroups(Group emailGroup, Group telGroup, Group postcodeGroup)
            {
                if (emailGroup != telGroup && emailGroup != null && telGroup != null)
                {
                    if (emailGroup.CanCombine(telGroup))
                    {
                        emailGroup.Add(telGroup.Entries);
                        UpdateIndexes(emailGroup, telGroup);
                        telGroup = null;
                    }
                    ;
                }
    
                if (emailGroup != postcodeGroup && emailGroup != null && postcodeGroup != null)
                {
                    if (emailGroup.CanCombine(postcodeGroup))
                    {
                        emailGroup.Add(postcodeGroup.Entries);
                        UpdateIndexes(emailGroup, postcodeGroup);
                        postcodeGroup = null;
                    }
                    ;
                }
    
                if (telGroup != postcodeGroup && telGroup != null && postcodeGroup != null)
                {
                    if (telGroup.CanCombine(postcodeGroup))
                    {
                        telGroup.Add(postcodeGroup.Entries);
                        UpdateIndexes(telGroup, postcodeGroup);
                        postcodeGroup = null;
                    }
                    ;
                }
            }
    
            private void UpdateIndexes(Group newGroup, Group oldGroup)
            {
                if (oldGroup.Email != null)
                    _emailGroups[oldGroup.Email] = newGroup;
    
                if (oldGroup.Tel != null)
                    _telGroups[oldGroup.Tel] = newGroup;
    
                if (oldGroup.PostCode != null)
                    _postcodeGroups[oldGroup.PostCode] = newGroup;
            }
    
            public class Group
            {
                public List<Entry> Entries = new List<Entry>();
    
                public Group(Entry entry)
                {
                    Email = entry.Email;
                    Tel = entry.Tel;
                    PostCode = entry.Postcode;
                    Entries.Add(entry);
                }
    
                public string Email { get; set; }
                public string Tel { get; set; }
                public string PostCode { get; set; }
    
                public bool Matches(Entry entry)
                {
                    if (Email != null && entry.Email != Email)
                        return false;
    
                    if (Tel != null && entry.Tel != Tel)
                        return false;
    
                    if (PostCode != null && entry.Postcode != PostCode)
                        return false;
    
                    return true;
                }
    
                public bool Add(Entry entry)
                {
                    if (!Matches(entry))
                        return false;
    
                    Entries.Add(entry);
    
                    if (Email == null && entry.Email != null)
                        Email = entry.Email;
    
                    if (Tel == null && entry.Tel != null)
                        Tel = entry.Tel;
    
                    if (PostCode == null && entry.Postcode != null)
                        PostCode = entry.Postcode;
    
                    return true;
                }
    
                public bool CanCombine(Group entry)
                {
                    if (Email != null && entry.Email != null && Email != entry.Email)
                        return false;
    
                    if (Tel != null && entry.Tel != null && Tel != entry.Tel)
                        return false;
    
                    if (PostCode != null && entry.PostCode != null && PostCode != entry.PostCode)
                        return false;
    
                    return true;
                }
    
                public void Add(List<Entry> entries)
                {
                    foreach (var entry in entries)
                    {
                        Add(entry);
                    }
                }
    
                public override string ToString()
                {
                    var sb = new StringBuilder();
    
                    sb.AppendLine($"Key: {Email ?? "null"} | {Tel ?? "null"} | {PostCode ?? "null"}");
    
                    foreach (var entry in Entries)
                    {
                        sb.AppendLine(entry.ToString());
                    }
    
                    return sb.ToString();
                }
            }
    
            public class Entry
            {
                public Entry(string name, string email, string tel, string postcode)
                {
                    Name = name;
                    Email = email;
                    Tel = tel;
                    Postcode = postcode;
                }
    
                public string Name { get; set; }
                public string Email { get; set; }
                public string Tel { get; set; }
                public string Postcode { get; set; }
    
                public override string ToString()
                {
                    return $"Entry: {Name ?? "null"} | {Email ?? "null"} | {Tel ?? "null"} | {Postcode ?? "null"}";
                }
            }
    
            [Test]
            public void Test()
            {
                var list = new List<Entry>
                {
                    new Entry("John S", null, null, "C67"),
                    new Entry("J Sim", null, "111", null),
                    new Entry("John Sim", "j@j.com", "111", "C67")
                };
    
                _emailGroups = new Dictionary<string, Group>();
                _telGroups = new Dictionary<string, Group>();
                _postcodeGroups = new Dictionary<string, Group>();
    
                foreach (var entry in list)
                {
                    Group emailGroup = null;
                    Group telGroup = null;
                    Group postcodeGroup = null;
    
                    if (entry.Email != null && _emailGroups.TryGetValue(entry.Email, out emailGroup))
                        if (!emailGroup.Add(entry)) emailGroup = null;
                    if (entry.Tel != null && _telGroups.TryGetValue(entry.Tel, out telGroup))
                        if (!telGroup.Add(entry)) telGroup = null;
                    if (entry.Postcode != null && _postcodeGroups.TryGetValue(entry.Postcode, out postcodeGroup))
                        if (!postcodeGroup.Add(entry)) postcodeGroup = null;
    
                    if (emailGroup == null && telGroup == null && postcodeGroup == null)
                    {
                        CreateGroup(entry);
                        continue;
                    }
    
                    CombineGroups(emailGroup, telGroup, postcodeGroup);
                }
    
                var groups = _emailGroups.Select(x => x.Value)
                    .Union(_telGroups.Select(x => x.Value))
                    .Union(_postcodeGroups.Select(x => x.Value))
                    .Distinct()
                    .ToList();
    
                foreach (var grp in groups)
                {
                    Console.WriteLine(grp.ToString());
                }
    
                groups.Should().HaveCount(1);
    
                groups.First().Entries.Should().HaveCount(3);
            }
        }
    }
